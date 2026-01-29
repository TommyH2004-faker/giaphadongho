
import { useState } from "react";
import './App.css'
import Navbar from "./layout/header-footer/Navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { AuthProvider } from "./utils/AuthContext";
import ToastContainer from "react-bootstrap/esm/ToastContainer";
import HomePage from "./layout/homepage/HomePage";
import { ConfirmProvider } from "material-ui-confirm";


const MyRoutes = () => {
  const [reloadAvatar] = useState(0);
  return (
    <>
      <Navbar key={reloadAvatar}/>
      <Routes>
        <Route path='/' element={<HomePage />} />
        {/* Other routes */}
      </Routes>
    </>
  );
};

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
          <ConfirmProvider>
            <MyRoutes />
            <ToastContainer
              position="bottom-center"
            />
          </ConfirmProvider>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
