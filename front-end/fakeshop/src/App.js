import { useEffect, useState } from "react";
import "./App.css";
import Login from "./pages/Login.js";
import Register from "./pages/Register";

function App() {

  const [token, setToken] = useState(localStorage.getItem("token"));
  const [screen, setScreen] = useState("login");

  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);

  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {

    if (!token) return;

    setLoading(true);

    fetch(`http://localhost:5062/api/products?pN=${page}`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
      .then(res => res.json())
      .then(data => {
        setProducts(data.products);
        setTotalPages(data.totalPages);
        setLoading(false);
      })
      .catch(() => setLoading(false));

  }, [page, token]);

  // LOGIN / REGISTER SCREENS
  if (!token) {

    if (screen === "login") {
      return (
        <Login
          onLogin={setToken}
          goRegister={() => setScreen("register")}
        />
      );
    }

    return (
      <Register
        goLogin={() => setScreen("login")}
      />
    );
  }

  const goNext = () => {
    if (page < totalPages) setPage(prev => prev + 1);
  };

  const goPrevious = () => {
    if (page > 1) setPage(prev => prev - 1);
  };

  return (
    <div className="app">

      <nav className="navbar">
        <div className="logo">FakeShop</div>

        <div className="nav-links">
          <span>Products</span>
          <span>About</span>
          <span className="cart">Cart 🛒</span>

          <button
            onClick={() => {
              localStorage.removeItem("token");
              setToken(null);
              setScreen("login");
            }}
          >
            Logout
          </button>
        </div>
      </nav>

      <header className="hero">
        <h1>Modern E-Commerce Experience</h1>
        <p>Built with ASP.NET Core + React</p>
      </header>

      <main className="container">

        {loading ? (
          <h2 className="loading">Loading products...</h2>
        ) : (
          <>
            <div className="products-grid">

              {products.map(product => (
                <div key={product.id} className="card">

                  <div className="image-wrapper">
                    <img src={product.productImageUrl} alt={product.name} />
                  </div>

                  <div className="card-body">
                    <h3>{product.name}</h3>
                    <p className="price">${product.price.toFixed(2)}</p>
                    <p className="vendor">{product.vendor?.name}</p>
                    <button className="btn">Add to Cart</button>
                  </div>

                </div>
              ))}

            </div>

            <div className="pagination">

              <button onClick={goPrevious} disabled={page === 1}>
                ← Previous
              </button>

              <span>
                Page {page} of {totalPages}
              </span>

              <button onClick={goNext} disabled={page === totalPages}>
                Next →
              </button>

            </div>
          </>
        )}

      </main>

      <footer className="footer">
        © 2026 FakeShop — Study Project
      </footer>

    </div>
  );
}

export default App;