import { Navbar, Container, Button } from "react-bootstrap";

const Header = () => {
  return (
    <Navbar bg="dark" variant="dark" expand="lg" fixed="top">
      <Container>
        <Navbar.Brand>Nhà Thờ Họ</Navbar.Brand>
        <Button variant="warning">Đăng nhập</Button>
      </Container>
    </Navbar>
  );
};

export default Header;
