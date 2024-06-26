import React, { useEffect, useState } from 'react';
import axios from 'axios';

function TestAPI() {
    const [data, setData] = useState(null);

    useEffect(() => {
        axios.get('/orders')
            .then(response => {
                console.log(response);
                setData(response.data);
            })
            .catch(error => console.error('Error fetching data: ', error));
    }, []);

    return (
        <div>
            <h1>API Response</h1>
            <pre>{JSON.stringify(data, null, 2)}</pre>
        </div>
    );
}

export default TestAPI;
