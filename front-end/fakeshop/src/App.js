import { useEffect, useState } from "react";
import "./App.css";

function App() {

  const [products, setProducts] = useState([]);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(false);

  const pageSize = 10;

  useEffect(() => {
    setLoading(true);

    fetch(`http://localhost:5062/api/products?pN=${page}&pS=${pageSize}`)
      .then(res => res.json())
      .then(data => {
        setProducts(data);
        setLoading(false);
      })
      .catch(() => setLoading(false));

  }, [page]);

  const goNext = () => {
    if (products.length === pageSize) {
      setPage(prev => prev + 1);
    }
  };

  const goPrevious = () => {
    if (page > 1) {
      setPage(prev => prev - 1);
    }
  };

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
          <>
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

            <div className="pagination">
              <button
                onClick={goPrevious}
                disabled={page === 1}
              >
                ← Previous
              </button>

              <span>Page {page}</span>

              <button
                onClick={goNext}
                disabled={products.length < pageSize}
              >
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