import axios from "axios";

/**
 * Register user
 * @param {*} data 
 * @returns 
 */
export async function register(data) {
    const response = await axios.post(process.env.REACT_APP_API + '/registration', data, {
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });
    return response.data;
}

export async function login(data) {
    const response = await axios.post(process.env.REACT_APP_API + '/login', data, {
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });
    return response.data;
}