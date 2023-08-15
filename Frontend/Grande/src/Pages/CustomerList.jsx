import React, { useEffect, useState } from 'react';

function CustomerList() {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    fetch('https://localhost:44308/api/customer')
      .then(response => response.json()) // Parse the response as JSON
      .then(data => setCustomers(data)) // Update the state with the parsed data
      .catch(error => console.error(error));
  }, []);

  return (
    <div>
      <h1>Customer List</h1>
      <ul>
        {customers && customers.map(customer => (
          <li key={customer.customer_id}>{customer.username}</li>
        ))}
      </ul>
    </div>
  );
}

export default CustomerList;