import { useEffect, useState } from "react";
import GoodsTable from "../Components/GoodsTable";

const GoodsList = () => {
  const [goodsList, setGoodsList] = useState(null);

  useEffect(() => {
    fetch("https://webapp-230912181654.azurewebsites.net/api/goods")
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
