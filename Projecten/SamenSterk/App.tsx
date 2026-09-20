import { Provider } from "react-redux";
import { store } from "./src/store/store";
import Root from "./src/components/Root";

export default function App() {
  return (
    <Provider store={store}>
      <Root />
    </Provider>
  );
}
