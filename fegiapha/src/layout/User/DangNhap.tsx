import React, { useState } from "react";
import type { FormEvent, ChangeEvent } from "react";
import { Button, TextField, IconButton, InputAdornment } from "@mui/material";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { jwtDecode } from "jwt-decode";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

import useScrollToTop from "../../hooks/ScrollToTop";
import { useAuth } from "../../utils/AuthContext";
import { endpointBe } from "../../utils/contant";
import type { JwtPayload } from "../admin/components/RequireAdmin";

const DangNhap: React.FC = () => {
  useScrollToTop();

  const navigate = useNavigate();
  const { setLoggedIn } = useAuth();

  // State
  const [tenDangNhap, setTenDangNhap] = useState<string>("");
  const [matKhau, setMatKhau] = useState<string>("");
  const [error, setError] = useState<string>("");
  const [showPassword, setShowPassword] = useState<boolean>(false);

  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const loginRequest = {
    tenDangNhap: tenDangNhap,
    matKhau: matKhau,
    };
    console.log("LOGIN REQUEST SEND:", loginRequest);

    fetch(endpointBe + "/api/ControllerLogin", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(loginRequest),
    })
      .then(async (response) => {
        if (!response.ok) {
          const errorText = await response.text();
          throw new Error(errorText);
        }
        return response.json();
      })

      .then((data) => {
        if (!data?.data?.token) {
        throw new Error("JWT không hợp lệ");
        }

        const token = data.data.token;

        const decodedToken = jwtDecode<JwtPayload>(token);
        console.log("DECODED TOKEN:", decodedToken);

        localStorage.setItem("token", token);

        setLoggedIn(true);

        toast.success("Đăng nhập thành công!");

        if (decodedToken.role === "ADMIN") {
          navigate("/admin/dashboard");
        } else {
          navigate("/");
        }
      })
      .catch(() => {
        setError("Tài khoản hoặc mật khẩu không đúng");
        toast.error("Tài khoản hoặc mật khẩu không đúng");
      });
  };

  return (
    <div
      className="container my-5 py-4 rounded-5 shadow bg-light"
      style={{ width: "450px" }}
    >
      <h1 className="text-center">ĐĂNG NHẬP</h1>

      {error && <p className="text-danger text-center">{error}</p>}

      <form
        onSubmit={handleSubmit}
        className="form"
        style={{ padding: "0 20px" }}
      >
        <TextField
          fullWidth
          required
          label="Tên đăng nhập"
          placeholder="Nhập tên đăng nhập"
          value={tenDangNhap}
          onChange={(e: ChangeEvent<HTMLInputElement>) =>
            setTenDangNhap(e.target.value)
          }
          className="input-field"
        />

        <TextField
          fullWidth
          required
          type={showPassword ? "text" : "password"}
          label="Mật khẩu"
          placeholder="Nhập mật khẩu"
          value={matKhau}
          onChange={(e: ChangeEvent<HTMLInputElement>) =>
            setMatKhau(e.target.value)
          }
          className="input-field"
          sx={{ mt: 2 }}
          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                <IconButton
                  onClick={() => setShowPassword(!showPassword)}
                  edge="end"
                >
                  {showPassword ? <VisibilityOff /> : <Visibility />}
                </IconButton>
              </InputAdornment>
            ),
          }}
        />

        <div className="d-flex justify-content-end mt-2 px-3">
          <span>
            Bạn chưa có tài khoản? <Link to="/dangKy">Đăng ký</Link>
          </span>
        </div>

        <div className="text-center my-3">
          <Button fullWidth variant="outlined" type="submit">
            Đăng nhập
          </Button>
        </div>
      </form>

      <div className="d-flex justify-content-end mt-2 px-3">
        <Link to="/forgot-password">Quên mật khẩu</Link>
      </div>
    </div>
  );
};

export default DangNhap;
