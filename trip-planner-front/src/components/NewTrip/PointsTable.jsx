import React, {useEffect, useState} from "react";
import {getAllPointsForTrip} from "../../services/point.service";
import {marker} from "leaflet/dist/leaflet-src.esm";

const Point = (id, lat, lng, address) => {
    return {
        id,
        lat,
        lng,
        address
    }
}

const initialState = [
        Point(1, 30.5590,27.5590, "NEw mexico"),
        Point(2, 33.5590,27.5590, "NEw mexxxxico"),
        Point(3, 27.5590,27.5590, "NEw mexico"),
        Point(4, 50.5590,27.5590, "NEw mexico"),
        Point(5, 60.5590,27.5590, "NEw mexico")
]

function PointsTable({tripId, update, setUpdate, setMarkers}) {
    const [points, setPoints] = useState([...initialState]);

    // useEffect(() => {
    //         getAllPointsForTrip(tripId)
    //             .then(data => {
    //                 setPoints(data);
    //                 setMarkers(data);
    //             })
    //             .then(() => setUpdate(false))
    //             .catch(() => {
    //                 setPoints([]);
    //                 setMarkers([]);
    //             })
    // }, []);

    useEffect(()=>{
        setMarkers(points);
    })

    return (
        <div className="card">
            <div className="card-header">
                <h3>List of points</h3>
            </div>
            <div className="card-body">
                <table className="table">
                    <tbody>
                    <tr>
                        <th>
                            Address
                        </th>
                    </tr>
                    {
                        points?.map((val, index) => {
                            return <tr key={index}
                                       onClick={() => setUpdate (val)}
                            >
                                <td>
                                    {val.address}
                                </td>
                            </tr>
                        })
                    }
                    </tbody>
                </table>
            </div>
        </div>
    )

}

export default PointsTable;
