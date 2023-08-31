import { useEffect, useState } from 'react';
import { useContext } from 'react';
import { UserContext } from '../main.jsx';

function CustomerList() {
  const [customers, setCustomers] = useState([]);
  const { user, setUser, login, logout } = useContext(UserContext);

  useEffect(() => {
    fetch('https://localhost:7037/api/GetUsers',
    {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + user.token //the space is necessary after "Bearer"
      },
    })
      .then(response => response.json()) // Parse the response as JSON
      .then(data => setCustomers(data)) // Update the state with the parsed data
      .catch(error => console.error(error));
  }, []);

  return (
    <div>
      <h1>Customer List</h1>
      <ul>
        {customers && customers.map(customer => (
          <li key={customer.id}>{customer.userName}</li>
        ))}
      </ul>
    </div>
  );
}

export default CustomerList;