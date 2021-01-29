import "./FirstPage.css";
import React, {useState} from 'react';
import {loginUser} from '../../services/auth.serivce';
import {useToasts} from 'react-toast-notifications'

const Login = ({setToken}) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { addToast } = useToasts()

    const onSubmit = async (e) => {
        e.preventDefault();

        const token = await loginUser({
            username,
            password
        });

        if (token) {
            setToken(token);
        } else {
            addToast("Wrong username or password.", {
                appearance: 'error',
                autoDismiss: true,
            });
        }
    }

    return (
        <div className="card m-3">
            <div className="card-body">
                <form onSubmit={onSubmit}>
                    <div className="form-group">
                        <label htmlFor="username">Username</label>
                        <input
                            type="text"
                            className="form-control"
                            id="username"
                            placeholder="Enter username"
                            required={true}
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input
                            type="password"
                            className="form-control"
                            id="password"
                            placeholder="Password"
                            required={true}
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>
            </div>
        </div>
    );
}

export default Login;
