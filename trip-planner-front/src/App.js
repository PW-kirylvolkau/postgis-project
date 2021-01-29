import React, {useState} from 'react';
import {BrowserRouter, Route, Switch, Link} from 'react-router-dom';
import Dashboard from "./components/Dashboard/Dashboard";
import NewTrip from "./components/NewTrip/NewTrip";
import {ToastProvider} from 'react-toast-notifications';
import FirstPage from "./components/FirstPage/FirstPage";
import {getToken, deleteToken} from './services/token.service';

function App() {
    const [token, setToken] = useState(getToken());
    const [active, setActive] = useState("dash");

    return (
        <div className="wrapper">
            <BrowserRouter>
                <nav className="navbar sticky-top navbar-dark bg-dark navbar-expand-lg">
                    <div className="container-fluid">
                        <div className="navbar-header">
                            <b><a className="navbar-brand">Trip Planner</a></b>
                        </div>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                                data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                                aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        {token ? <div className="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul className="nav navbar-nav">
                                <li className="nav-item mx-3">
                                    <a className={"nav-link " + active === "dash" ? "active" : ""} href="#">
                                        <Link to="/" onClick={() => setActive("dash")}>Dashboard</Link>
                                    </a>
                                </li>
                                <li className="nav-item mx-3">
                                    <a className={"nav-link " + active === "trip" ? "active" : ""} href="#">
                                        <Link onClick={() => setActive("trip")} to="/trip/new">Add trip</Link>
                                    </a>
                                </li>
                                <li className="nav-item mx-3">
                                    <button className="btn btn-light"
                                            onClick={() => {
                                                deleteToken();
                                                setToken(null);
                                            }
                                            }>Logout
                                    </button>
                                </li>
                            </ul>
                        </div> : <></>}
                    </div>
                </nav>
                <div className="container">
                    {token ?
                        <Switch>
                            <Route exact={true} path="/">
                                <Dashboard/>
                            </Route>
                            <Route path="/trip/new">
                                <NewTrip/>
                            </Route>
                        </Switch>
                        :
                        <ToastProvider>
                            <FirstPage setToken={setToken}/>
                        </ToastProvider>
                    }
                </div>


            </BrowserRouter>
        </div>
    );
}

export default App;
