# Azure Functions ChatOps Handler #

This provides a sample handler code for ChatOps using Microsoft Teams.


## Getting Started ##

### Environment Variables ###

Either your `local.settings.json` or Configurations on Azure Functions app instance, configure the following values:

* "GitHub__AuthKey": "<github_api_authentication_key>",
* "GitHub__BaseUri": "https://api.github.com/",
* "GitHub__Endpoints__Dispatches": "repos/{0}/{1}/dispatches",
* "GitHub__Headers__Accept": "application/vnd.github.v3+json",
* "GitHub__Headers__UserAgent": "<user_agent_name>"


### Request Payload ###

When sending an API request to the endpoint, the request payload format **SHOULD** comply at least the following:

```json
{
  "event_type": "<event_type>",
  "client_payload": {
    "artifact": {
      "name": "<artifact_name>"
    },
    "repository": {
      "owner": "<repository_owner>",
      "name": "<repository_name>"
    }
  }
}
```

You **MAY** add more fields to `client_payload`, `artifact` or `repository`, but this is the minimal payload structure that the API expects.


### GitHub Actions Workflow ###

The repository you are sending this event, **SHOULD** have at least one workflow definition YAML file that takes the `repository_dispatch` event like:

```yaml
name: <workflow_name>
on: repository_dispatch
jobs:
...
```


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `master` branch for review.


## License ##

This is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2020 [Dev Kimchi](https://devkimchi.com)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
