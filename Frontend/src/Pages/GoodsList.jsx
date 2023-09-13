import { useEffect, useState } from "react";
import GoodsTable from "../Components/GoodsTable";

const GoodsList = () => {
  const [goodsList, setGoodsList] = useState(null);
  const url = import.meta.env.VITE_APP_MY_URL;

  useEffect(() => {
    fetch(url + "/api/goods")
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
