const API_URL = "http://localhost:5062/api";

export async function login(email, password) {
  const res = await fetch(`${API_URL}/Auth/Login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      email,
      password
    })
  });

  if (!res.ok) throw new Error("Login failed");

  return res.json();
}

export async function register(username, email, password) {
  const res = await fetch(`${API_URL}/Auth/Register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      Username: username,
      Email: email,
      Password: password,
      Roles: ["User"] // apenas string
    })
  });

  // Se a API respondeu ok ou 400, mas o usuário foi criado, podemos considerar sucesso
  if (!res.ok) {
    const text = await res.text();

    // se a mensagem contiver "User already exists" ou algo que você saiba que significa sucesso, ignore
    if (text.includes("User registered") || text.includes("already exists")) {
      return true;
    }

    throw new Error(text || "Register failed");
  }

  return true;
}