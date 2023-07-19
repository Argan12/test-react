import { useState } from "react";
import { getPosts } from "../../Services/PostService";
import moment from "moment/moment";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { icon } from "@fortawesome/fontawesome-svg-core";

export default function Posts() {
    const [posts, setPosts] = useState([]);

    getPosts().then((posts) => {
        setPosts(posts);
    });

    if (posts.length == 0) {
        return (
            <div class="post-container">
                <div class="m-auto spinner-border text-dark" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
            </div> 
        );
    }

    return (
        <div class="post-container">
            {posts.map((post) => (
                <div class="card" key={post.articleId}>
                    <div class="card-header">
                        <h1>{post.title}</h1>
                        <div class="post-date">
                            <span>Le {moment(post.date).format("DD/MM/yyyy")}</span>
                            <span>Par {post.pseudo}</span>
                        </div>
                    </div>
                    <div class="card-body">
                        <p>{post.content}</p>
                    </div>
                    {
                        (post.userId == localStorage.getItem('id')) 
                            ? <div class="card-actions">
                                  <a href="#">
                                    <FontAwesomeIcon icon="fa-solid fa-pen" />
                                  </a>
                              </div>
                            : <div>Pas moi</div>
                    }
                </div>                
            ))}
        </div>
    );
}