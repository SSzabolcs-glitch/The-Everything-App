import { useEffect, useState } from 'react';
import { useContext } from 'react';
import { UserContext } from '../main.jsx';

import CustomerTable from "../Components/CustomerTable/CustomerTable.jsx";

const updateCustomer = (updatedcustomer, email, user) => {
  console.log(email)
  console.log("CUSTOMER UPDATE - PUT")
  return fetch(`https://localhost:7037/api/UpdateUser?email=${encodeURIComponent(email)}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
      'Authorization': 'Bearer ' + user.token
    },
    body: JSON.stringify(updatedcustomer),
  })
  .then(data => {
    console.log('Customer updated successfully:', data);
  })
  .catch(error => {
    console.error('Error updating customer:', error);
    throw error;
  });
};

const deleteCustomer = (email, user) => {
  console.log(email),
  console.log(user.userName, user.token),
  console.log("CUSTOMER DELETE")
  return fetch(`https://localhost:7037/api/DeleteUser?email=${encodeURIComponent(email)}`, {
    method: "DELETE",
      headers: {
      'Authorization': 'Bearer ' + user.token
    },
  });
};

function CustomerList() {
  const [customers, setCustomers] = useState([]);
  const { user, setUser, login, logout } = useContext(UserContext);

  useEffect(() => {
    fetch("https://localhost:7037/api/GetUsers",
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
  }, [user.token]);
  

  const handleUpdate = (newUsername, email) => {
    console.log(email);
    console.log(newUsername["customer-username"]);
    console.log("handleUpdate");

    let updatedCustomer = customers.find(c=> c.email === email);
    updatedCustomer.userName = newUsername["customer-username"];

    console.log(updatedCustomer);

    updateCustomer(updatedCustomer, email, user)
    .then(() => {
      //after a successful update, updating the local state as well
      setCustomers(prevCustomers => {
        const updatedCustomers = prevCustomers.map(c => {
          if (c.email === email) {
            return { ...c, userName: newUsername["customer-username"] };
          }
          return c;
        });
        return updatedCustomers;
      });
    });
  };

  const handleDelete = (email) => {
    console.log(email)
    console.log("handleDelete")
    deleteCustomer(email, user)
    .then(() => {
      //after a successful delete, updating the local state
      setCustomers(prevCustomers => prevCustomers.filter(c => c.email !== email));
    });
}

  return (
    <div>
      <>
      <CustomerTable 
      customers={customers}
      onDelete={handleDelete}
      onUpdate={handleUpdate}
      />
      </>
    </div>
  );
}

export default CustomerList;