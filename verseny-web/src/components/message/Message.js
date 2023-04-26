import "./message.css";

function Message(props){
    return (
        <div className="message-container">
            <div className={props.cName}>
                <div className="picture-text">
                    <h1>{props.title}</h1>
                    <p>{props.text}</p>
                    <a href={props.url} className={props.btnClass}>{props.buttonText}</a>
                    <a href={props.url} className={props.btnClass2}>{props.buttonText2}</a>
                </div>
            </div>
        </div>
  )
  }
export default Message;