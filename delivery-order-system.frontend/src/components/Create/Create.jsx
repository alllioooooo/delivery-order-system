import React, { useState } from "react";
import axios from "axios";
import Card from "../Card/Card";
import { useNavigate } from "react-router-dom";

const Create = () => {
  const [formData, setFormData] = useState({
    senderCity: "",
    senderAddress: "",
    receiverCity: "",
    receiverAddress: "",
    weight: "",
    pickupDate: "",
  });

  const navigate = useNavigate();

  const [formErrors, setFormErrors] = useState({});

  const handleChange = (e) => {
    const { name, value } = e.target;

    if (name === "weight") {
      const cleanedValue = value.replace(/[^0-9.]/g, "");
      setFormData({
        ...formData,
        [name]: cleanedValue,
      });
    } else {
      setFormData({
        ...formData,
        [name]: value,
      });
    }
  };

  const validateForm = () => {
    let errors = {};
    if (!formData.senderCity.trim()) errors.senderCity = "Поле не заполнено";
    if (!formData.senderAddress.trim()) errors.senderAddress = "Поле не заполнено";
    if (!formData.receiverCity.trim()) errors.receiverCity = "Поле не заполнено";
    if (!formData.receiverAddress.trim()) errors.receiverAddress = "Поле не заполнено";
    if (!formData.weight.trim()) {
      errors.weight = "Поле не заполнено";
    } else if (isNaN(formData.weight)) {
      errors.weight = "Вес должен быть числом";
    }
    if (!formData.pickupDate.trim()) errors.pickupDate = "Поле не заполнено";

    setFormErrors(errors);
    return Object.keys(errors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!validateForm()) {
      return;
    }
    try {
      const date = new Date(formData.pickupDate);
      const formattedDate = date.toISOString().split("T")[0] + "T00:00:00Z";
      const response = await axios.post("http://localhost:8000/orders/create", {
        ...formData,
        pickupDate: formattedDate,
      }, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      const result = response.data;
      console.log(result);
      navigate(result.orderId)
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <Card
      url={
        "https://static.tildacdn.com/tild3036-3761-4339-b832-383763666562/__1.png"
      }
    >
      <h2 className="text-3xl pb-2">Создать заказ</h2>
      <form
        onSubmit={handleSubmit}
        className="flex flex-col gap-2 flex-grow justify-between"
      >
        <div className="flex flex-col">
          <label>Город отправки</label>
          <input
            type="text"
            name="senderCity"
            className="border rounded-lg p-2"
            placeholder="Санкт-Петербург"
            value={formData.senderCity}
            onChange={handleChange}
          />
          {formErrors.senderCity && (
            <span className="text-red-500">{formErrors.senderCity}</span>
          )}
        </div>
        <div className="flex flex-col">
          <label>Адрес отправки</label>
          <input
            type="text"
            name="senderAddress"
            className="border rounded-lg p-2"
            placeholder="Кронверский Пр-кт д.49"
            value={formData.senderAddress}
            onChange={handleChange}
          />
          {formErrors.senderAddress && (
            <span className="text-red-500">{formErrors.senderAddress}</span>
          )}
        </div>
        <div className="flex flex-col">
          <label>Город куда отправить</label>
          <input
            type="text"
            name="receiverCity"
            className="border rounded-lg p-2"
            placeholder="Сыктывкар"
            value={formData.receiverCity}
            onChange={handleChange}
          />
          {formErrors.receiverCity && (
            <span className="text-red-500">{formErrors.receiverCity}</span>
          )}
        </div>
        <div className="flex flex-col">
          <label>Адрес куда отправить</label>
          <input
            type="text"
            name="receiverAddress"
            className="border rounded-lg p-2"
            placeholder="Пр-кт Ленина д.4"
            value={formData.receiverAddress}
            onChange={handleChange}
          />
          {formErrors.receiverAddress && (
            <span className="text-red-500">{formErrors.receiverAddress}</span>
          )}
        </div>
        <div className="flex gap-5">
          <div className="flex flex-col w-full">
            <label>Вес, кг</label>
            <input
              type="text"
              name="weight"
              className="border rounded-lg p-2"
              placeholder="20"
              value={formData.weight}
              onChange={handleChange}
            />
            {formErrors.weight && (
              <span className="text-red-500">{formErrors.weight}</span>
            )}
          </div>
          <div className="flex flex-col w-full">
            <label>Дата</label>
            <input
              type="date"
              name="pickupDate"
              className="border rounded-lg p-2"
              value={formData.pickupDate}
              onChange={handleChange}
            />
            {formErrors.pickupDate && (
              <span className="text-red-500">{formErrors.pickupDate}</span>
            )}
          </div>
        </div>
        <button
          className="py-2 px-4 bg-slate-100 hover:bg-slate-200 rounded-lg"
          type="submit"
        >
          Создать заказ
        </button>
      </form>
    </Card>
  );
};

export default Create;
