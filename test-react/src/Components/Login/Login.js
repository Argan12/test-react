import { useState } from "react";
import Navbar from "../Navbar";
import { Toaster, toast } from "react-hot-toast";
import { login } from "../../Services/AuthService";
import Loader from "../Loader";

export function Login() {
    const [isLoading, setIsLoading] = useState(false);
    const [formData, setFormData] = useState({
        mail: '',
        password: ''
      });

    const handleSubmit = async (event) => {
        event.preventDefault();
        setIsLoading(true);

        await login(formData).then((response) => {
            localStorage.setItem("id", response.user.id);
            localStorage.setItem("jwt", response.jwt);
            localStorage.setItem("refreshToken", response.refreshToken);
            window.location.href = "/";
        }, (error) => {
            setIsLoading(false);
            var message = error.response.status == 500
                ? "Une erreur s'est produite"
                : error.response.data.message;
            toast.error(message);
        });
        setFormData({
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
        <section id="login">
            <Navbar />
            <Toaster position="top-right" />
            <h2 className="text-center">Se connecter</h2>

            <form onSubmit={handleSubmit} id="search-form" className="row g-3">
                <div className="col-12">
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
                    <button 
                        type="submit" 
                        id="loginBtn" 
                        className="btn btn-primary mb-3">{isLoading ? <Loader /> : 'Se connecter'}</button>
                </div>
            </form>
        </section>
    );
}