function ProductCard({ product }) {
  return (
    <div className="card">
      <img src={product.productImageUrl} alt={product.name} />
      <h3>{product.name}</h3>
      <p>${product.price.toFixed(2)}</p>
      <p>{product.vendor?.name}</p>
      <button>Add to Cart</button>
    </div>
  );
}

export default ProductCard;