import { useEffect, useState } from "react";
import GoodsTable from "../Components/GoodsTable";
require('dotenv').config();

const dbConnectionUrl = process.env.REACT_APP_DB_CONNECTION_URL;

const GoodsList = () => {
  const [goodsList, setGoodsList] = useState(null);

  useEffect(() => {
    fetch(dbConnectionUrl + "/api/goods")
      .then((res) => res.json())
      .then((goods) => setGoodsList(goods))
      .catch((error) => {
        console.error("Error fetching goods list:", error);
      });
  }, []);

  if (goodsList === null) {
    return <div>Loading...</div>;
  }

  return <GoodsTable goodsList={goodsList}/>;
};

export default GoodsList;
