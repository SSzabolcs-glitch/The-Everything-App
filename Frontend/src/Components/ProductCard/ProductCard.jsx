import React from 'react';
import './ProductCard.css';

const ProductCard = ({ product , addToCart }) => {
 
  return (
    <div className="product-card">
      <img src={product.imageUrl} alt={product.name} />
      <h3>{product.productName}</h3>
      <p>Quantity:{product.quantity}</p>
      <p>Price: {product.unitPrice}</p>
      <button onClick={() => addToCart(product)}>Add to Cart</button>
    </div>
  );
};

export default ProductCard;