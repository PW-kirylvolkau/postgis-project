import React, {useState} from 'react';
import NewTripMap from "./NewTripMap";
import NewTripForm from "./NewTripForm";
import {ToastProvider} from "react-toast-notifications";
import NewPointForm from "./NewPointForm";
import PointsTable from "./PointsTable";

const NewTrip = (props) => {
    const [trip, setTrip] = useState();
    const [update, setUpdate] = useState(false);
    const [markers, setMarkers] = useState([]);

    return (
        <div className="container">
            <div className="row">
                <div className="col-sm-6">
                    <div className="row mb-3">
                        <ToastProvider>
                            <NewTripForm saveTrip = {(value) => setTrip(value)}/>
                        </ToastProvider>
                    </div>
                    {trip ? <div className="row mb-3">
                            <ToastProvider>
                                <NewPointForm
                                    tripId={trip.id}
                                    setUpdate={setUpdate}
                                />
                            </ToastProvider>
                            <ToastProvider>
                                <PointsTable
                                    tripId={trip.id}
                                    update={update}
                                    setUpdate={setUpdate}
                                    setMarkers={setMarkers}
                                />
                            </ToastProvider>
                        </div>
                         : <></> }
                </div>
                <div className="col-sm-6">
                    <NewTripMap markers={markers}/>
                </div>
            </div>

        </div>
    )
}

export default NewTrip;
