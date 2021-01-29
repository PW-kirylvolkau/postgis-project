import React from "react";

function TripGeneral({id, name}) {
    return (
        <div className="container">
            <div className="row">
                <div className="col-sm-6">
                    <b>Id</b>
                </div>
                <div className="col-sm-6">
                    {id}
                </div>
            </div>
            <div className="row">
                <div className="col-sm-6">
                    <b>Name</b>
                </div>
                <div className="col-sm-6">
                    {name}
                </div>
            </div>
        </div>
    )
}

export default TripGeneral;
