import { useState } from "react";
import { register } from "../Api";
import "./Login.css";

function Register({ goLogin }) {

  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e) => {
  e.preventDefault();  
  try {
      await register(username, email, password);   
      alert("User created successfully!");     
      goLogin();
  } catch (err) {
      alert("Register failed: " + err.message);
  }
  };

  return (
    <div className="login-page">

      <div className="login-card">

        <h1 className="login-title">FakeShop</h1>
        <p className="login-subtitle">Create your account</p>

        <form onSubmit={handleSubmit} className="login-form">

          <input
            type="text"
            placeholder="Username"
            value={username}
            onChange={e => setUsername(e.target.value)}
            required
          />

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
            Register
          </button>

        </form>

        <p className="auth-link">
          Already have an account?{" "}
          <span onClick={goLogin}>Login here</span>
        </p>

      </div>

    </div>
  );
}

export default Register;