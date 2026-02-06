import { Tree, TreeNode } from 'react-organizational-chart';
import { Box, Card, CardContent, Typography, Avatar, Chip } from '@mui/material';
import { Male, Female, CalendarToday } from '@mui/icons-material';
import type { GiaPhaTreeResponse, GiaPhaNode, VoChongDto } from '../../../types/giaPha.types';

interface Props {
  treeData: GiaPhaTreeResponse;
}

export const GiaPhaTreeView = ({ treeData }: Props) => {

  // =======================
  // Helpers
  // =======================

  const formatDate = (dateString: string) => {
    if (!dateString) return '';
    const date = new Date(dateString);
    return date.toLocaleDateString('vi-VN');
  };

  const calculateAge = (birthDate: string, deathDate?: string | null) => {
    const birth = new Date(birthDate);
    const end = deathDate ? new Date(deathDate) : new Date();
    return end.getFullYear() - birth.getFullYear();
  };

  // Lấy mảng con từ API ($values hoặc array thường)
  const getChildren = (member: GiaPhaNode): GiaPhaNode[] => {
    const raw: unknown = member.con;
    if (Array.isArray(raw)) return raw as GiaPhaNode[];
    if (
      typeof raw === 'object' && raw !== null &&
      '$values' in raw && Array.isArray((raw as { $values: unknown }).$values)
    ) {
      return (raw as { $values: GiaPhaNode[] }).$values;
    }
    return [];
  };

  // Lấy danh sách vợ/chồng an toàn
  const getSpouses = (member: GiaPhaNode): VoChongDto[] => {
    const raw: unknown = member.danhSachVoChong;
    if (Array.isArray(raw)) return raw as VoChongDto[];
    if (
      typeof raw === 'object' && raw !== null &&
      '$values' in raw && Array.isArray((raw as { $values: unknown }).$values)
    ) {
      return (raw as { $values: VoChongDto[] }).$values;
    }
    return [];
  };

  // =======================
  // Member Card
  // =======================

  const MemberCard = ({
    member,
    isSpouse = false,
  }: {
    member: GiaPhaNode | VoChongDto;
    isSpouse?: boolean;
  }) => {

    const gioiTinh = 'gioiTinh' in member ? member.gioiTinh : true;
    const ngayMat = member.ngayMat;
    const isAlive = !ngayMat;
    
    // Lấy avatar nếu có (cả GiaPhaNode và VoChongDto đều có avatar)
    const avatarUrl = member.avatar;
    const hasAvatar = avatarUrl && avatarUrl.trim() !== '';

    return (
      <Card
        sx={{
          minWidth: 200,
          maxWidth: 250,
          border: isSpouse ? '2px dashed #f48fb1' : '2px solid #1976d2',
          borderRadius: 2,
          boxShadow: 3,
          bgcolor: isAlive ? 'background.paper' : '#f5f5f5',
        }}
      >
        <CardContent>

          {/* Avatar */}
          <Box display="flex" alignItems="center" gap={1} mb={1}>
            <Avatar
              src={hasAvatar ? avatarUrl : undefined}
              sx={{
                bgcolor: gioiTinh ? '#f48fb1' : '#42a5f5',
                width: 48,
                height: 48,
              }}
            >
              {!hasAvatar && (gioiTinh ? <Female /> : <Male />)}
            </Avatar>

            <Box flex={1}>
              <Typography fontWeight="bold">
                {member.hoTen?.trim()}
              </Typography>

              <Chip
                size="small"
                label={gioiTinh ? 'Nữ' : 'Nam'}
                color={gioiTinh ? 'secondary' : 'primary'}
              />
            </Box>
          </Box>

          {/* Ngày sinh */}
          <Box display="flex" gap={0.5}>
            <CalendarToday sx={{ fontSize: 14 }} />
            <Typography variant="caption">
              {formatDate(member.ngaySinh)}
              {isAlive && ` (${calculateAge(member.ngaySinh)} tuổi)`}
            </Typography>
          </Box>

          {/* Ngày mất */}
          {ngayMat && (
            <Typography variant="caption" color="error">
              ✝ {formatDate(ngayMat)} (
              {calculateAge(member.ngaySinh, ngayMat)} tuổi)
            </Typography>
          )}

          {/* Đời */}
          {'level' in member && (
            <Typography variant="caption" color="primary">
              Đời {member.level + 1}
            </Typography>
          )}
        </CardContent>
      </Card>
    );
  };

  // =======================
  // Family Node (Recursive)
  // =======================

  const FamilyNode = ({ member }: { member: GiaPhaNode }) => {

    const spouses = getSpouses(member);
    const children = getChildren(member);

    // Không có vợ/chồng
    if (spouses.length === 0) {
      return (
        <TreeNode label={<MemberCard member={member} />}>
          {children.map((child) => (
            <FamilyNode key={child.id} member={child} />
          ))}
        </TreeNode>
      );
    }

    // Có vợ/chồng
    return (
      <TreeNode
        label={
          <Box display="flex" justifyContent="center" alignItems="center" gap={2}>
            {/* Chồng / vợ chính */}
            <MemberCard member={member} />
            {/* Danh sách vợ/chồng */}
            {spouses.map((sp) => (
              <Box key={sp.voChongId} textAlign="center">
                <MemberCard member={sp} isSpouse />
                {sp.ngayKetHon && (
                  <Typography variant="caption">
                    ⚭ {formatDate(sp.ngayKetHon)}
                  </Typography>
                )}
              </Box>
            ))}
          </Box>
        }
      >
        {children.map((child) => (
          <FamilyNode key={child.id} member={child} />
        ))}
      </TreeNode>
    );
  };

  // =======================
  // Render
  // =======================

  return (
    <Box sx={{ p: 3, bgcolor: '#f5f7fa', minHeight: '100vh' }}>

      {/* Header */}
      <Box textAlign="center" mb={4}>
        <Typography variant="h3" fontWeight="bold" color="#e90c0c">
          GIA PHẢ  <span style={{ color: '#e90c0c' , textTransform: 'uppercase' }}>{treeData.tenHo}</span>
        </Typography>

        <Box display="flex" justifyContent="center" gap={2} mt={2}>
          <Chip label={`${treeData.tongSoThanhVien} thành viên`} />
          <Chip label={`${treeData.soCapDo} đời`} />
          <Chip label={`Thủy tổ: ${treeData.thuyTo.hoTen}`} />
        </Box>
      </Box>

      {/* Tree */}
      <Box sx={{ overflow: 'auto', bgcolor: 'white', p: 3 }}>
        <Tree
          lineWidth="2px"
          lineColor="#1976d2"
          lineBorderRadius="10px"
          label={<Box />}
        >
          <FamilyNode member={treeData.thuyTo} />
        </Tree>
      </Box>
    </Box>
  );
};
