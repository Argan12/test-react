import { useState } from "react";
import Navbar from "../Navbar";
import { Toaster, toast } from "react-hot-toast";
import { register } from "../../Services/AuthService";

export function Register() {
    const [formData, setFormData] = useState({
        pseudo: '',
        mail: '',
        password: ''
      });

    const handleSubmit = async (event) => {
        event.preventDefault();
        await register(formData).then((response) => {
            toast.success("Votre compte a bien été créé !");
        }, (error) => {
            var message = error.response.status == 500
                ? "Une erreur s'est produite"
                : error.response.data.message;
            toast.error(message);
        });
        setFormData({
            pseudo: '',
            mail: '',
            password: ''
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
        <section id="registration">
            <Navbar />
            <Toaster position="top-right" />
            <h2 className="text-center">S'inscrire</h2>

            <form onSubmit={handleSubmit} id="search-form" className="row g-3">
                <div className="col-12">
                    <input 
                        type="text" 
                        name="pseudo" 
                        className="form-control mb-2"
                        value={formData.pseudo}
                        onChange={handleInputChange}
                        placeholder="Pseudo" />
                    <input 
                        type="text" 
                        name="mail" 
                        className="form-control mb-2"
                        value={formData.mail}
                        onChange={handleInputChange}
                        placeholder="Adresse e-mail" />
                    <input 
                        type="password" 
                        name="password" 
                        className="form-control mb-2"
                        value={formData.password}
                        onChange={handleInputChange}
                        placeholder="Mot de passe" />
                </div>
                <div className="col-auto">
                    <button type="submit" className="btn btn-primary mb-3">S'inscrire</button>
                </div>
            </form>
        </section>
    );
}