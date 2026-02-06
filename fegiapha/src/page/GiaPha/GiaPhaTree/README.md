# 🌳 Cây Gia Phả Component

## 📦 Cài đặt

```bash
cd fegiapha
npm install react-organizational-chart @mui/material @emotion/react @emotion/styled @mui/icons-material axios
```

## 🚀 Sử dụng

### 1. Thêm route vào App.tsx:

```tsx
import { GiaPhaPage } from './page/GiaPha/GiaPhaPage';

function App() {
  return (
    <Routes>
      <Route path="/gia-pha" element={<GiaPhaPage />} />
      {/* other routes */}
    </Routes>
  );
}
```

### 2. Hoặc sử dụng component trực tiếp:

```tsx
import { GiaPhaTreeView } from './components/GiaPhaTree/GiaPhaTreeView';

function MyPage() {
  return <GiaPhaTreeView hoId="your-ho-id-here" />;
}
```

## 🎨 Features

### ✅ Đã implement:

- [x] Hiển thị cây gia phả với layout đẹp
- [x] Card thông tin thành viên với avatar, giới tính
- [x] Hiển thị chồng + vợ (có thể nhiều vợ)
- [x] Hiển thị con cái theo cấp bậc
- [x] Thông tin ngày sinh, tuổi
- [x] Đánh dấu người đã mất (✝)
- [x] Hiển thị thông tin hôn nhân (ngày cưới, số con)
- [x] Level/Đời của mỗi thành viên
- [x] Hover effect và interactive
- [x] Responsive và scrollable
- [x] Selector chọn họ
- [x] Loading và error handling

### 🎨 Màu sắc:

- **Nam giới:** Border xanh dương (#1976d2)
- **Nữ giới (vợ):** Border hồng dashed (#f48fb1)
- **Người còn sống:** Background trắng
- **Người đã mất:** Background xám (#f5f5f5)

### 📊 Thông tin hiển thị:

```
┌─────────────────────────┐
│  👤 Avatar (M/F icon)   │
│  Họ Tên (bold)          │
│  Nam/Nữ chip           │
│  📅 Ngày sinh (tuổi)    │
│  ✝ Ngày mất (nếu có)   │
│  ❤️ X vợ, Y con        │
│  Đời Z                  │
└─────────────────────────┘
```

### 🏗️ Cấu trúc Component:

```
GiaPhaPage (Container)
  └─ GiaPhaTreeView (Fetch & Display)
      ├─ Header (Title + Stats)
      ├─ Tree (react-organizational-chart)
      │   └─ FamilyNode (Recursive)
      │       ├─ MemberCard (Chồng)
      │       ├─ MemberCard (Vợ 1, 2, ...)
      │       └─ FamilyNode (Con 1, 2, ...)
      └─ Loading/Error states
```

## 🔧 Customization

### Thay đổi màu sắc:

```tsx
// Trong MemberCard component
border: isSpouse ? '2px dashed #YOUR_COLOR' : '2px solid #YOUR_COLOR'
```

### Thay đổi kích thước card:

```tsx
minWidth: 200,  // Thay đổi width ở đây
maxWidth: 250,
```

### Thay đổi line style của tree:

```tsx
<Tree
  lineWidth="2px"      // Độ dày đường nối
  lineColor="#1976d2"  // Màu đường nối
  lineBorderRadius="10px"  // Bo tròn góc
>
```

## 📱 API Integration

Component kết nối với backend qua:

```
GET /api/GiaPha/{hoId}/tree
```

Response format đã chuẩn với structure:

```typescript
{
  isSuccess: boolean;
  data: {
    tenHo: string;
    hoId: string;
    thuyTo: GiaPhaNode;  // Root node
    tongSoThanhVien: number;
    soCapDo: number;
  }
}
```

## 🐛 Troubleshooting

### Không hiển thị cây:

1. Kiểm tra API URL trong `.env`:
   ```
   VITE_API_URL=http://localhost:5000/api
   ```

2. Kiểm tra CORS trong backend (Program.cs):
   ```csharp
   app.UseCors("AllowFrontendApp");
   ```

### Lỗi layout:

- Đảm bảo container có đủ chiều cao: `minHeight: '100vh'`
- Tree component cần space để render: thêm `overflowX: 'auto'`

### Performance với cây lớn:

- Giới hạn `maxLevel` khi gọi API
- Lazy load các nhánh con (TODO: implement)
- Virtualization cho cây rất lớn (TODO: implement)

## 🚧 TODO - Tính năng mở rộng:

- [ ] Search/filter thành viên trong cây
- [ ] Collapse/expand từng nhánh
- [ ] Export cây ra PDF/Image
- [ ] Zoom in/out và pan
- [ ] Click vào member để xem chi tiết đầy đủ
- [ ] Edit mode (thêm/sửa/xóa thành viên)
- [ ] Print layout optimization
- [ ] Dark mode support
- [ ] Multiple view modes (vertical, horizontal)
- [ ] Statistical dashboard (số nam/nữ, tuổi trung bình, etc)

## 📝 Notes

- Component sử dụng **react-organizational-chart** thay vì react-d3-tree vì:
  - Dễ customize hơn
  - Layout đẹp hơn cho family tree
  - Tích hợp tốt với Material-UI
  - Performance tốt với cây vừa và nhỏ

- Thủy tổ luôn ở level 0
- Con cái được sắp xếp theo ngày sinh (OrderBy trong backend)
- Hỗ trợ đa thê (nhiều vợ)
