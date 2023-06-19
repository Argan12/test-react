import axios from "axios";

export async function search(query) {
    try {
        const response = await axios.get("https://api.gwereve.fr/api/event_places", {
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            }
        });
        return response.data;
    } catch (error) {
        console.error(error);
        return [];
    }
}