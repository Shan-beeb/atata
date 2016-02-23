﻿using _ = Atata.Tests.BasicControlsPage;

namespace Atata.Tests
{
    [TitleContains("Basic Controls")]
    [NavigateTo("http://localhost:50549/BasicControls.html")]
    public class BasicControlsPage : Page<BasicControlsPage>
    {
        [FindByCss("h1")]
        public Text<_> Header { get; private set; }

        public FindByLabel ByLabel { get; private set; }

        public FindById ById { get; private set; }

        public Button<_> RawButton { get; private set; }

        public Button<_> InputButton { get; private set; }

        public Link<_> LinkButton { get; private set; }

        public Button<_> DisabledButton { get; private set; }

        public Button<_> MissingButton { get; private set; }

        [UIComponent("*")]
        public class FindByLabel : Control<_>
        {
            public TextInput<_> FirstName { get; private set; }

            [Term(TermMatch.StartsWith)]
            public TextInput<_> LastName { get; private set; }

            [Term(TermFormat.SentenceWithColon)]
            public TextInput<_> MiddleName { get; private set; }
        }

        [UIComponent("*")]
        [FindFields(FindTermBy.Id)]
        public class FindById : Control<_>
        {
            [FindById(TermFormat.Dashed)]
            public TextInput<_> FirstName { get; private set; }

            [Term(TermFormat.Camel)]
            public TextInput<_> LastName { get; private set; }

            [Term(TermFormat.Pascal)]
            public TextInput<_> MiddleName { get; private set; }
        }
    }
}