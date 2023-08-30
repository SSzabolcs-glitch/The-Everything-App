import { useContext } from 'react';
import UserContext from './UserContext';

const UserProfile = () => {
  const { user, setUser, login, logout } = useContext(UserContext);

  return (
    <div>
      {user ? (
        <div>
          <h2>Hello, {user.username}!</h2>
          {/*<button onClick={logout}>Log Out</button>*/}
        </div>
      ):(null)}
    </div>
  );
};

export default UserProfile;