import { useContext } from 'react';
import { UserContext } from '../../main.jsx'; //named import
import "./UserProfile.css"; //default import

const UserProfile = () => {
  const { user, setUser, login, logout } = useContext(UserContext);

  return (
    <div>
      {user ? (
        <div>
          <h2>Hello, {user.userName}!</h2>
        </div>
      ):(null)}
    </div>
  );
};

export default UserProfile;