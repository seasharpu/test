import React, { useState } from 'react';
import './App.css';
import { NumbersDto, ApiResponse } from './interfaces'; // Import interfaces from separate file

async function CalculatorSumRequest(numbersDto: NumbersDto): Promise<ApiResponse> {
    const requestOptions: RequestInit = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(numbersDto)
    };

    const response = await fetch("http://localhost:5093/calculator/sum", requestOptions);
    if (!response.ok) {
        const errorMessage = await response.text(); // Extract error message from response body
        throw new Error(`Error fetching data: ${response.statusText}. Details: ${errorMessage}`);
    }
    const data: ApiResponse = await response.json();
    return data;
}

function App() {
    const [inputValue, setInputValue] = useState<string>(''); // State to hold input value
    const [result, setResult] = useState<string | null>(null); // State to hold API response result
    const [error, setError] = useState<string | null>(null); // State to hold error message

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value); // Update input value state
    };

    const handleButtonClick = async () => {
        try {
            const trimmedInputValue = inputValue.trim(); // Trim whitespace from inputValue
            const numbersDto: NumbersDto = { numbers: trimmedInputValue === '' ? '' : trimmedInputValue }; // Send empty string if trimmedInputValue is empty
            const response = await CalculatorSumRequest(numbersDto); // Send API request with NumbersDto
            setResult(response.numbers); // Update result state with API response
            setError(null); // Clear any previous errors
        } catch (error) {
            setError(error.message); // Set error state with detailed error message
            setResult(null); // Clear result on error
        }
    };

    return (
        <>
            <div className="Wrapper">
                <input
                    type="text"
                    value={inputValue}
                    onChange={handleInputChange} // Update input value on change
                    placeholder="Enter numbers separated by commas"
                />
                <button onClick={handleButtonClick}>Add</button>
                {error && <div className="Error">Error: {error}</div>} {/* Display detailed error message if there's an error */}
                <div className="Response">Response: {result !== null ? result : 'Waiting for response...'}</div> {/* Display API response */}
            </div>
        </>
    )
}

export default App;
