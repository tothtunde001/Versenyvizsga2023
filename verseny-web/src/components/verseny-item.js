import { Link } from "react-router-dom";

function VersenyItem(props) {
    const verseny = props.verseny;
    let button;


    if (verseny.submitted) {
        button = <Link to={"/verseny-form/" + verseny.id } className="btn btn-success">Eredményem</Link>;
    }
    else {
        button = <Link to={"/verseny-form/" + verseny.id} className="btn btn-warning">Kitöltöm</Link>;
    }

    return (
        <div className="card m-3">
            <div className="card-body">

                <div className="row">
                    <div className="col-8">
                        <h5 className="card-title">{verseny.competition_name}</h5>
                        <div className="container">{verseny.description}</div>
                    </div>
                    <div className="col-4">
                        { button }
                    </div>
                </div>

             </div>
        </div>
         
    );
}

export default VersenyItem;