import axios from "axios";
import { async } from "q";

/**
 * Create new article
 * @param {*} data 
 * @returns 
 */
export async function newPost(data) {
    const response = await axios.post(process.env.REACT_APP_API + '/article/create', data, {
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": "Bearer " + localStorage.getItem('jwt')
        }
    });
    return response.data;
}

export async function getPosts() {
    const response = await axios.get(process.env.REACT_APP_API + '/article/all', {
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });
    return response.data;
}