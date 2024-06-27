import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import OrderList from './components/OrderList';

ReactDOM.createRoot(document.getElementById('app')).render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<OrderList />} />
                {/* Добавьте здесь дополнительные маршруты, например для создания заказа */}
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);
