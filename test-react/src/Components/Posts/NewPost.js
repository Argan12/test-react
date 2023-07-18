import { Toaster, toast } from "react-hot-toast";
import Loader from "../Loader";
import Navbar from "../Navbar";
import { useState } from "react";
import { newPost } from "../../Services/PostService";

export default function NewPost() {
    const [isLoading, setIsLoading] = useState(false);
    const [formData, setFormData] = useState({
        title: '',
        content: ''
      });

      const handleSubmit = async (event) => {
        event.preventDefault();
        setIsLoading(true);

        let json = formData;
        json = { ...json, author: localStorage.getItem('id') };
        
        await newPost(json).then((response) => {
            toast.success("L'article a bien été publié !");
            setIsLoading(false);
        }, (error) => {
            setIsLoading(false);
            var message = error.response.status == 500
                ? "Une erreur s'est produite"
                : error.response.data.message;
            toast.error(message);
        });
        // await login(formData).then((response) => {
        //     localStorage.setItem("id", response.user.id);
        //     localStorage.setItem("jwt", response.jwt);
        //     localStorage.setItem("refreshToken", response.refreshToken);
        //     window.location.href = "/";
        // }, (error) => {
        //     setIsLoading(false);
        //     var message = error.response.status == 500
        //         ? "Une erreur s'est produite"
        //         : error.response.data.message;
        //     toast.error(message);
        // });
        setFormData({
            title: '',
            content: ''
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
            <h2 className="text-center">Publier un article</h2>

            <form onSubmit={handleSubmit} id="post-form" className="row g-3">
                <div className="col-12">
                    <input 
                        type="text" 
                        name="title" 
                        className="form-control mb-2"
                        value={formData.title}
                        onChange={handleInputChange}
                        placeholder="Titre" />
                    <textarea 
                        name="content" 
                        className="form-control mb-2"
                        value={formData.content}
                        onChange={handleInputChange}
                        placeholder="Contenu"></textarea>
                </div>
                <div className="col-auto">
                    <button 
                        type="submit" 
                        id="postBtn" 
                        className="btn btn-primary mb-3">{isLoading ? <Loader /> : 'Publier'}</button>
                </div>
            </form>
        </section>
    );
}