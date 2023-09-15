import React, { useState } from 'react';
import './CartWindow.css';

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
        <div className='shopping-cart-main-text'>Shopping Cart</div>
      </div>

      <ul>
        {cartItems.map((item) => (

          <li className='cart-list-item' key={item.id}>
            <b>{item.productName}</b> - ${item.unitPrice} <br></br>quantity: {
              <input className="order-quantity-input-field" defaultValue ={item.quantity}
              onChange={(event) => { item.quantity = parseInt(event.target.value);}}/>}
              
          <div className="cart-remove-button-container">
            <button className="cart-remove-button" onClick={() => removeFromCart(item.id)}>X</button>
          </div>
          </li>

        ))}
      </ul>

      <div className="order-form">
        <div className='order-information-main-text'>Order Information</div>
        <label className="order-shipping-address-label" htmlFor="order-shipping-address">Shipping Address:</label><br></br>
        <textarea className='order-shipping-address-text-area'
          id="address"
          value={address}
          onChange={(e) => setAddress(e.target.value)}
          placeholder="Enter your shipping address"
        ></textarea><br></br>
        <button className="place-order-button" onClick={handlePlaceOrder}>Place Order</button>
      </div>
    </div>
  );
};

export default CartWindow;