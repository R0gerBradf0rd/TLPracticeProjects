import { elements } from "./dom.js";

function isValidJson(jsonString) {
  try {
    JSON.parse(jsonString);
    return true;
  } catch {
    alert('Невалидный JSON!');
    return false;
  }
}

function compareJson(oldObj, newObj) {
  const result = {};
  
  for (const key in oldObj) {
    if (!newObj.hasOwnProperty(key)) {
      result[key] = {
        type: "deleted",
        oldValue: oldObj[key]
      };
    } else if (JSON.stringify(oldObj[key]) !== JSON.stringify(newObj[key])) {
      result[key] = {
        type: "changed",
        oldValue: oldObj[key],
        newValue: newObj[key]
      };
    } else {
      result[key] = {
        type: "unchanged",
        oldValue: oldObj[key],
        newValue: newObj[key]
      };
    }
  }

  for (const key in newObj) {
    if (!oldObj.hasOwnProperty(key)) {
      result[key] = {
        type: "new",
        newValue: newObj[key]
      };
    }
  }

  return result;
}

export function initCompare() {
  elements.startButton.addEventListener('click', () => {      
    elements.welcomeSection.style.display = 'none';
    elements.jsonSection.style.display = 'grid';      
  });

  elements.compareButton.addEventListener('click', () => {  
    const oldJson = elements.oldJson.value;
    const newJson = elements.newJson.value;
    
    if (!isValidJson(oldJson) || !isValidJson(newJson)) return;
    
    const result = compareJson(JSON.parse(oldJson), JSON.parse(newJson));
    elements.compareResult.value = JSON.stringify(result, null, 2); 
  });
}