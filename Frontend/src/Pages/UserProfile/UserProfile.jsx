import { Link } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from '../../main.jsx'; //named import
import "./UserProfile.css"; //default import

const UserProfile = () => {
  const { user, setUser, login, logout } = useContext(UserContext);

  return (
    <div className="profile-container">
      {user ? (
        <div className="profile-welcome-text">
          <h2>Hello, {user.userName}!</h2>
        </div>
      ):(null)}
      {
        user.userName == "admin" ? (
          <div className="admin-buttons-container">
            <Link to="/customerlist">
              <button type="button" className="admin-button">Customer list</button>
            </Link>
            <Link to="/productlist">
            <button type="button" className="admin-button">Product list</button>
            </Link>
            <Link to="/orderlist">
            <button type="button" className="admin-button">Order list</button>
            </Link>
          </div>
        
        ) : (null)
      }
    </div>
  );
};

export default UserProfile;