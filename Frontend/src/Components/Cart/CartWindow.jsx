import React, { useState } from 'react';

const CartWindow = ({ isOpen, closeCart, cartItems, removeFromCart, placeOrder  }) => {
  const [address, setAddress] = useState('');
  const [orderItems, setOrderItems] = useState([]);
  
  const handlePlaceOrder = () => {
  
    const orderItem = {
      address,
      items: cartItems,
    };

    console.log(cartItems);
    placeOrder(orderItem);

    setOrderItems([...orderItems, orderItem]);
    removeFromCart(cartItems.map((item) => item.id));
    setAddress('');
  };
  const cartWindowStyle = {
    display: isOpen ? 'block' : 'none',
  };
  return (
    <div className="cart-window" style={cartWindowStyle}>
      <div className="cart-header">
        <h2>Shopping Cart</h2>
        <button className="close-button" onClick={closeCart}>
          X
        </button>
      </div>
      <ul>
        {cartItems.map((item) => (
          <li key={item.id}>
            {item.productName} - ${item.unitPrice} quantity { <input
        defaultValue ={item.quantity}
        onChange={(event) => {
          
          item.quantity = parseInt(event.target.value);
        }}
        
      />}
     
            <button onClick={() => removeFromCart(item.id)}>Remove</button>
          </li>
        ))}
      </ul>
      <div className="order-form">
        <h3>Order Information</h3>
        <label htmlFor="address">Shipping Address:</label>
        <textarea
          id="address"
          value={address}
          onChange={(e) => setAddress(e.target.value)}
          placeholder="Enter your shipping address"
        ></textarea>
        <button onClick={handlePlaceOrder}>Place Order</button>
      </div>
    </div>
  );
};

export default CartWindow;