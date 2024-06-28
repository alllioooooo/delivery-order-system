import { useEffect } from "react";
import Card from "../Card/Card";
import { useParams } from "react-router-dom";
import axios from "axios";

import { useNavigate } from "react-router-dom";

const Details = () => {
  let { id } = useParams();
  const navigate = useNavigate();

  const handleFetchOrderDetails = async (id) => {
    try {
      const response = await axios.get(`http://localhost:8000/orders/${id}`, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      setOrderDetails((prevDetails) => ({
        ...prevDetails,
        id: response.data,
      }));
    } catch (error) {
      console.error(`Error fetching order ${id} details:`, error);
    }
  };

  useEffect(() => {
    handleFetchOrderDetails(id);
  }, []);

  return (
    <Card
      url={
        "https://img.freepik.com/premium-photo/delivery-man-smile-shipping-box-portrait-employee-studio-with-courier-service-boxes-supply-chain-happiness-export-worker-with-distribution-online-shopping-mail-services_590464-168792.jpg"
      }
    >
      <div className="gap-5 flex flex-col justify-between h-full">
        <div>
          <div>
            <h1 className="text-2xl">Спасибо!</h1>
            <p className="opacity-50">Заказ успешно создан</p>
          </div>
          <div className="mt-4">
            <p>
              <strong>Номер вашего заказа:</strong>
            </p>
          </div>
          <div>{id}</div>
        </div>
        <button
          className="py-2 px-4 w-full bg-slate-100 hover:bg-slate-200 rounded-lg"
          onClick={() => {
            navigate("/all");
          }}
        >
          Перейти ко всем заказам
        </button>
      </div>
    </Card>
  );
};

export default Details;
