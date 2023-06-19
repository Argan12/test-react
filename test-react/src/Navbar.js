import { Link } from "react-router-dom";

export default function Navbar() {
    return (
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Navbar</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <Link to="/" className="nav-link">Accueil</Link>
                        </li>
                        <li class="nav-item">
                            <Link to="/search" className="nav-link">Rechercher</Link>
                        </li>
                    </ul>
                    <form class="d-flex" role="search">
                        <input class="form-control me-2" type="text" placeholder="E-mail" />
                        <input class="form-control me-2" type="text" placeholder="Mot de passe" />
                        <button class="btn btn-outline-success" type="submit">Connexion</button>
                    </form>
                </div>
            </div>
        </nav>
    );
}