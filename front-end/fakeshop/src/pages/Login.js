import { useState } from "react";
import { login } from "../Api";
import "./Login.css";

function Login({ onLogin, goRegister }) {

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const data = await login(email, password);

      localStorage.setItem("token", data.jwtToken);

      onLogin(data.jwtToken);

    } catch {
      alert("Login failed");
    }
  };

  return (
    <div className="login-page">

      <div className="login-card">

        <h1 className="login-title">FakeShop</h1>
        <p className="login-subtitle">Sign in to your account</p>

        <form onSubmit={handleSubmit} className="login-form">

          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={e => setEmail(e.target.value)}
            required
          />

          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={e => setPassword(e.target.value)}
            required
          />

          <button type="submit">
            Login
          </button>

        </form>

        <p className="auth-link">
          Don't have an account?{" "}
          <span onClick={goRegister}>Create one here</span>
        </p>

      </div>

    </div>
  );
}

export default Login;