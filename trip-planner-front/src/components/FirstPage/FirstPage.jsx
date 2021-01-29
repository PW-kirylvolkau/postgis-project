import React from 'react';
import Login from "./Login";
import Readme from "./Readme";

function FirstPage({setToken}) {
    return (
        <div className="container">
            <div className="row vh-100">
                <div className="col-sm-5 my-auto">
                    <Login setToken={setToken}/>
                </div>
                <div className="col-sm-7">
                    <Readme/>
                </div>
            </div>
        </div>
    )
}

export default FirstPage;
