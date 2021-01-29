import React, {useState} from 'react';
import NewTripMap from "./NewTripMap";
import NewTripForm from "./NewTripForm";
import {ToastProvider} from "react-toast-notifications";
import NewPointForm from "./NewPointForm";

const NewTrip = (props) => {
    const [trip, setTrip] = useState();

    return (
        <div className="container">
            <div className="row">
                <div className="col-sm-4">
                    <div className="row mb-3">
                        <ToastProvider>
                            <NewTripForm saveTrip = {(value) => setTrip(value)}/>
                        </ToastProvider>
                    </div>

                    {trip ? <div className="row mb-3">
                            <ToastProvider>
                                <NewPointForm tripId={trip.id}/>
                            </ToastProvider>
                        </div>
                         : <></> }
                </div>
                <div className="col-sm-8">
                    <NewTripMap />
                </div>
            </div>

        </div>
    )
}

export default NewTrip;
