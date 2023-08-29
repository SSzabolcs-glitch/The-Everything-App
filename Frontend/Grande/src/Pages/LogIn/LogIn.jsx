import { useState } from "react";
//import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import CustomerForm from "../../Components/CustomerForm/CustomerForm.jsx";
import "./LogIn.css";

const loginUser = (user) => {
  console.log(user);
  return fetch("https://localhost:7037/Auth/Login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(user),
  }).then((res) => res.json());
};

const LogIn = () => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [token, setToken] = useState("");

  const handleLogIn = (user) => {
    console.log(user)
    setLoading(true);
    loginUser(user)
      .then((data) => {
        setLoading(false);
        setToken(data.token);
        navigate("/");
      })
  };

  return (
    <CustomerForm
      onCancel={() => navigate("/")}
      onSave={handleLogIn}
      disabled={loading}
      isRegister={false}
    />
  );
};

export default LogIn;
