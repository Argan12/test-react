import { Link } from "react-router-dom";

function logout() {
    localStorage.clear();
    window.location.href = "/";
}

export default function Navbar() {
    var connection = null;

    if (localStorage.getItem("id")) {
        connection = 
        <div className="d-flex" role="search">
            <a href="#" onClick={logout} className="nav-link me-3">Se déconnecter</a>
        </div>;
    } else {
        connection = 
        <div className="d-flex" role="search">
            <Link to="/login" className="nav-link me-3">Se connecter</Link>
            <Link to="/register" className="nav-link">S'inscrire</Link>
        </div>;
    }
    
    return (
        <nav className="navbar navbar-expand-lg bg-body-tertiary">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">Navbar</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link to="/" className="nav-link">Accueil</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/search" className="nav-link">Rechercher</Link>
                        </li>
                    </ul>
                    
                    {connection}
                </div>
            </div>
        </nav>
    );
}