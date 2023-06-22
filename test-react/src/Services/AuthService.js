import axios from "axios";

export async function register(data) {
    const response = await axios.post(process.env.REACT_APP_API + '/registration', data, {
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });
    return response.data;
}