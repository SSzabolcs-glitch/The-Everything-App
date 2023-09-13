import { useState } from "react";
//import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import CustomerForm from "../../Components/CustomerForm/CustomerForm.jsx";
import "./SignUp.css";

const createCustomer = (customer) => {
  console.log(customer);
  const dbConnectionUrl = process.env.REACT_APP_DB_CONNECTION_URL;

  return fetch(dbConnectionUrl + "/Auth/Register", {
    method: "POST",
    mode: "cors",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(customer),
  }).then((res) => res.json());
};

const SignUp = () => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);

  const handleCreateCustomer = (customer) => {
    console.log(customer)
    setLoading(true);
    createCustomer(customer)
      .then(() => {
        setLoading(false);
        navigate("/");
      })
  };

  return (
    <CustomerForm
      onCancel={() => navigate("/")}
      onSave={handleCreateCustomer}
      disabled={loading}
      isRegister={true}
    />
  );
};

export default SignUp;
