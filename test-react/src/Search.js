import { useState } from "react";
import Navbar from "./Navbar";
import './Search.css';
import { search } from "./Services/DeezerService";

export function Search() {
    const [formData, setFormData] = useState({
        search: ''
      });

    const handleSubmit = async (event) => {
        event.preventDefault();
        await search(formData.search).then((response) => {
            console.log(response);
        });
        setFormData({
            search: ''
        });
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevData) => ({
          ...prevData,
          [name]: value
        }));
      };

    return (
        <section id="search">
            <Navbar />
            <h2 className="text-center">Rechercher</h2>

            <form onSubmit={handleSubmit} id="search-form" className="row g-3">
                <div className="col-12">
                    <input 
                        type="search" 
                        name="search" 
                        className="form-control"
                        value={formData.search}
                        onChange={handleInputChange}
                        placeholder="Rechercher un artiste, une musique..." />
                </div>
                <div className="col-auto">
                    <button type="submit" className="btn btn-primary mb-3">Rechercher</button>
                </div>
            </form>
        </section>
    );
}