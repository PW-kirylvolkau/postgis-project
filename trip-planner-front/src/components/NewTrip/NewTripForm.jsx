import React, {useState} from "react";
import {createTrip} from '../../services/trip.service';
import {useToasts} from "react-toast-notifications";
import TripGeneral from "./TripGeneral";

function NewTripForm({saveTrip}) {
    const [name, setName] = useState("");
    const [tripCreated, setTripCreated] = useState(false);
    const [description, setDescription] = useState("");
    const [trip, setTrip] = useState();
    const { addToast } = useToasts();

    const onSubmit = async (e) => {
        e.preventDefault();

        const payload = {
            name,
            description
        };

        const createdTrip = await createTrip(payload);

        if(createdTrip) {
            setTrip(createdTrip);
            saveTrip(createdTrip);
            setTripCreated(true);
        }
        else {
            addToast("Problem occurred with trip creation", {
                appearance: 'error',
                autoDismiss: true,
            });
        }
    }

    return (
        <div className="card m-3">
            <div className="card-header">
                <h3>New Trip</h3>
            </div>
            <div className="card-body">
                { tripCreated ? <TripGeneral id={trip.id} name={trip.name} /> : <form onSubmit={onSubmit}>
                    <div className="form-group">
                        <label htmlFor="name">Trip name</label>
                        <input
                            type="text"
                            className="form-control"
                            id="name"
                            placeholder="Enter trip name"
                            required={true}
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="description">Trip description</label>
                        <textarea
                            id="description"
                            className="form-control"
                            name="description"
                            rows="4"
                            cols="50"
                            value={description}
                            onChange={(e) => {
                                setDescription(e.target.value)
                            }}
                        />
                    </div>
                    <button className="btn btn-dark" type="submit">
                        Create trip
                    </button>
                </form>
                }
            </div>
        </div>
    )
}

export default NewTripForm;
