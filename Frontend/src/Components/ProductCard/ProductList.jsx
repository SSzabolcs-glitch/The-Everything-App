import React, { useState, useEffect } from 'react';
import ProductCard from './ProductCard';
import Cart from '../Cart/Cart';
import CartWindow from '../Cart/CartWindow';
import './ProductList.css';

const ProductList = () => {
  const [products, setProducts] = useState([]);
  const [cart, setCart] = useState([]);
  const [isCartOpen, setIsCartOpen] = useState(false);
  const apiUrl = 'https://webapp-230912181654.azurewebsites.net/api/product/getall';

  const toggleCart = () => {
    setIsCartOpen(!isCartOpen);
  };

  const placeOrder = (orderItem) => {
   console.log(orderItem);
    fetch('https://webapp-230912181654.azurewebsites.net/api/orders/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(orderItem),
    })
      .then((response) => {
        if (response.ok) {

          console.log('Order placed successfully');
        } else {

          console.error('Failed to place the order');
        }
      })
      .catch((error) => {
        console.error('Network error:', error);
      });
  };

  useEffect(() => {
    fetch(apiUrl)
      .then((response) => response.json())
      .then((data) => setProducts(data))
      .catch((error) => console.error('Error fetching data:', error));
  }, []);

  const addToCart = (product) => {
    setCart([...cart, product]);
  };

  const removeFromCart = (productId) => {
    const updatedCart = cart.filter((item) => item.id !== productId);
    setCart(updatedCart);
  };
  console.log(cart);
  return (
    <div className='cart-and-product-list'>

      <div className="product-list-container">
       
       {products.map((product) => (
         <ProductCard
           key={product.id}
           product={product}
           addToCart={addToCart}
         />
       ))}
     </div>

      <div className='cart-container'>
       <button className="cart-toggle-button" onClick={toggleCart}>
          {isCartOpen ? 'Close Cart' : 'Open Cart'}
        </button>
        <CartWindow
        isOpen={isCartOpen}
        closeCart={toggleCart}
        cartItems={cart}
        removeFromCart={removeFromCart}
        placeOrder={placeOrder}
      />
      </div>



    </div>

  );
};

export default ProductList;