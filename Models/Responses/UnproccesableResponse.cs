using System;
using System.Collections;

namespace AuthApi.Models.Responses {
    public class UnprocesableResponse {
        public string Title {get;set;} = default!;
        public IDictionary<string, string> Errors {get;set;} = default!;

        public UnprocesableResponse(){
            this.Title = "Uno o mas campos tienen error.";
        }

        public UnprocesableResponse(string title, IDictionary<string, string> errors ){
            this.Title = title;
            this.Errors = errors;
            
        }

        public UnprocesableResponse(IDictionary<string, string> errors ){
            this.Title = "Uno o mas campos tienen error.";
            this.Errors = errors;
        }

        public UnprocesableResponse(IDictionary<string, object> errors ){
            this.Title = "Uno o mas campos tienen error.";
            this.Errors = errors.ToDictionary( el => el.Key, el => {
                if (el.Value is Array array)
                {
                    return array.GetValue(0)?.ToString() ?? string.Empty;
                }
                else if (el.Value is IEnumerable enumerable && !(el.Value is string))
                {
                    var firstItem = enumerable.Cast<object>().FirstOrDefault();
                    return firstItem?.ToString() ?? string.Empty;
                }
                else
                {
                    return el.Value?.ToString() ?? string.Empty;
                }
            })!;
        }

        public UnprocesableResponse(List<FluentValidation.Results.ValidationFailure> errors ){
            var errorsGrouped = errors.GroupBy( p => p.PropertyName);
            var errorsMaps = errorsGrouped.ToDictionary(g=>g.Key, g=>string.Join(", ", g.Select(i=>i.ErrorMessage)));

            this.Title = "Uno o mas campos tienen error.";
            this.Errors = errorsMaps;
        }

    }
}