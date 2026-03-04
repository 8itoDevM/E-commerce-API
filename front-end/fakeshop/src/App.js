import { useEffect, useState } from "react";
import "./App.css";

function App() {

  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("http://localhost:5062/api/products")
      .then(res => res.json())
      .then(data => {
        setProducts(data);
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, []);

  return (
    <div className="app">

      <nav className="navbar">
        <div className="logo">FakeShop</div>
        <div className="nav-links">
          <span>Products</span>
          <span>About</span>
          <span className="cart">Cart 🛒</span>
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
          <div className="products-grid">
            {products.map(product => (
              <div key={product.id} className="card">
                <div className="image-wrapper">
                  <img
                    src={product.productImageUrl}
                    alt={product.name}
                  />
                </div>

                <div className="card-body">
                  <h3>{product.name}</h3>

                  <p className="price">
                    ${product.price.toFixed(2)}
                  </p>

                  <p className="vendor">
                    {product.vendor?.name}
                  </p>

                  <button className="btn">
                    Add to Cart
                  </button>
                </div>
              </div>
            ))}
          </div>
        )}

      </main>

      <footer className="footer">
        © 2026 FakeShop — Backend Focused E-Commerce Study Project
      </footer>

    </div>
  );
}

export default App;